package com.group4.DLS.service;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import com.group4.DLS.domain.dto.response.FileDownloadResponse;
import com.group4.DLS.domain.dto.response.FileUploadResponse;
import com.group4.DLS.domain.entity.FileMetadata;
import com.group4.DLS.repository.FileMetadataRepository;

import jakarta.transaction.Transactional;

@Service
@Transactional
public class FileService {
    
    @Autowired
    private SeaweedFSService seaweedFSService;

    @Autowired
    private FileMetadataRepository fileMetadataRepository;

    /**
     * Upload file to SeaweedFS and save metadata to database
     */
    public FileMetadata uploadAndSave(MultipartFile file) throws IOException {
        // Upload file to SeaweedFS
        FileUploadResponse uploadResponse = seaweedFSService.uploadFile(file);

        // Create metadata entity
        FileMetadata metadata = new FileMetadata();
        metadata.setFileId(uploadResponse.getFileId());
        metadata.setFileName(uploadResponse.getFileName());
        metadata.setContentType(uploadResponse.getContentType());
        metadata.setFileSize(uploadResponse.getFileSize());
        metadata.setFileUrl(uploadResponse.getFileUrl());

        // Save metadata to database
        return fileMetadataRepository.save(metadata);
    }

    /**
     * Get file metadata by file ID
     */
    public FileMetadata getFileMetadata(String fileId) {
        return fileMetadataRepository.findByFileId(fileId)
                .orElseThrow(() -> new RuntimeException("File metadata not found for ID: " + fileId));
    }

    /**
     * Get all files
     */
    public Iterable<FileMetadata> getAllFiles() {
        return fileMetadataRepository.findAll();
    }

    /**
     * Download file by database ID
     */
    public FileDownloadResponse downloadFile(String id) throws IOException {
        FileMetadata metadata = getFileMetadata(id);
        byte[] content = seaweedFSService.downloadFile(metadata.getFileId());

        return FileDownloadResponse.builder()
                .content(content)
                .fileName(metadata.getFileName())
                .contentType(metadata.getContentType())
                .build();
    }

    /**
     * Delete file from both SeaweedFS and database
     */
    public void deleteFile(String id) throws IOException {
        FileMetadata metadata = getFileMetadata(id);

        // Delete from SeaweedFS
        seaweedFSService.deleteFile(metadata.getFileId());

        // Delete metadata from database
        fileMetadataRepository.deleteById(id);
    }

    /**
     * Get all image files
     */
    public Iterable<FileMetadata> getAllImageFiles() {
        return fileMetadataRepository.findByContentTypeStartingWith("image/");
    }
}
