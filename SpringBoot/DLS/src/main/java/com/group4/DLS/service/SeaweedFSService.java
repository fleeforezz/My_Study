package com.group4.DLS.service;

import java.io.IOException;

import org.springframework.stereotype.Service;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.util.MultiValueMap;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.core.io.ByteArrayResource;
import org.springframework.http.HttpEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;

import com.group4.DLS.config.SeaweedFSProperties;
import com.group4.DLS.domain.dto.response.AssignResponse;
import com.group4.DLS.domain.dto.response.FileUploadResponse;
import com.group4.DLS.domain.dto.response.LookupResponse;

@Service
public class SeaweedFSService {
    private final SeaweedFSProperties seaweedFSProperties;
    private final RestTemplate restTemplate;

    public SeaweedFSService(SeaweedFSProperties seaweedFSProperties) {
        this.seaweedFSProperties = seaweedFSProperties;
        this.restTemplate = new RestTemplate();
    }

    /**
     * Upload file and return FileUploadResponse with URL
     */
    public FileUploadResponse uploadFile(MultipartFile file) throws IOException {
        // Step 1: Get file ID from SeaweedFS master server
        String assignUrl = seaweedFSProperties.getMaster().getUrl() + "/dir/assign";
        AssignResponse assignResponse = restTemplate.getForObject(assignUrl, AssignResponse.class);

        if (assignResponse == null || assignResponse.getId() == null) {
            throw new IOException("Failed to get file ID from SeaweedFS");
        }

        // Step 2: Upload file to the assigned volume server
        String uploadUrl = "http://" + assignResponse.getPublicUrl() + "/" + assignResponse.getId();

        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.MULTIPART_FORM_DATA);

        MultiValueMap<String, Object> body = new LinkedMultiValueMap<>();
        body.add("file", new ByteArrayResource(file.getBytes()) {
            @Override
            public String getFilename() {
                return file.getOriginalFilename();
            }
        });

        HttpEntity<MultiValueMap<String, Object>> requestEntity = new HttpEntity<>(body, headers);
        ResponseEntity<String> response = restTemplate.postForEntity(uploadUrl, requestEntity, String.class);

        if (!response.getStatusCode().is2xxSuccessful()) {
            throw new IOException("File upload failed with status: " + response.getStatusCode());
        }

        // Build the public URL
        String fileUrl = seaweedFSProperties.getPublicUrl().getUrl() + "/" + assignResponse.getId();
        return FileUploadResponse.builder()
                .fileId(assignResponse.getId())
                .fileUrl(fileUrl)
                .fileName(file.getOriginalFilename())
                .contentType(file.getContentType())
                .fileSize(file.getSize())
                .build();
    }

    /**
     * Download file from SeaweedFS
     */
    public byte[] downloadFile(String fileId) throws IOException {
        String lookupUrl = seaweedFSProperties.getMaster().getUrl() + "/dir/lookup?volumeId=" + extractVolumeId(fileId);
        LookupResponse lookupResponse = restTemplate.getForObject(lookupUrl, LookupResponse.class);

        if (lookupResponse == null || lookupResponse.getLocations() == null || lookupResponse.getLocations().isEmpty()) {
            throw new IOException("File not found in SeaweedFS");
        }

        String downloadUrl = "http://" + lookupResponse.getLocations().get(0).getPublicUrl() + "/" + fileId;
        ResponseEntity<byte[]> response = restTemplate.getForEntity(downloadUrl, byte[].class);

        if (response.getStatusCode().is2xxSuccessful()) {
            return response.getBody();
        } else {
            throw new IOException("File download failed with status: " + response.getStatusCode());
        }
    }

    /**
     * Delete file from SeaweedFS
     */
    public void deleteFile(String fileId) throws IOException {
        String lookupUrl = seaweedFSProperties.getMaster().getUrl() + "/dir/lookup?volumeId=" + extractVolumeId(fileId);
        LookupResponse lookupResponse = restTemplate.getForObject(lookupUrl, LookupResponse.class);

        if (lookupResponse == null || lookupResponse.getLocations() == null || lookupResponse.getLocations().isEmpty()) {
            throw new IOException("File not found in SeaweedFS");
        }

        String deleteUrl = "http://" + lookupResponse.getLocations().get(0).getUrl() + "/" + fileId;
        restTemplate.delete(deleteUrl);
    }

    private String extractVolumeId(String fileId) {
        return fileId.split(",")[0];
    }
}
