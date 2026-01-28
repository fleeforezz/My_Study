package com.group4.DLS.controller;

import org.springframework.http.ContentDisposition;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.apache.hc.core5.http.HttpStatus;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

import com.group4.DLS.domain.dto.response.FileDownloadResponse;
import com.group4.DLS.domain.entity.FileMetadata;
import com.group4.DLS.service.FileService;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;


@RestController
@RequestMapping("/api/v1/files")
public class FileController {

    @Autowired
    private FileService fileService;

    /**
     * Upload file - saves to SeaweedFS and database
     */
    @PostMapping("/upload")
    public ResponseEntity<FileMetadata> uploadFile(@RequestParam("file") MultipartFile file) {
        try {
            FileMetadata metadata = fileService.uploadAndSave(file);
            return ResponseEntity.ok(metadata);
        } catch (Exception e) {
            return ResponseEntity.status(500).build();
        }
    }
    
    /**
     * Get all files metadata
     */
    @GetMapping
    public ResponseEntity<Iterable<FileMetadata>> getAllFiles() {
        Iterable<FileMetadata> files = fileService.getAllFiles();
        return ResponseEntity.ok(files);
    }

    /**
     * Get file metadata by ID
     */
    @GetMapping("/{id}")
    public ResponseEntity<FileMetadata> getFileMetadata(@PathVariable String id) {
        try {
            FileMetadata metadata = fileService.getFileMetadata(id);
            return ResponseEntity.ok(metadata);
        } catch (Exception e) {
            return ResponseEntity.notFound().build();
        }
    }

    /**
     * Download file by database ID
     */
    @GetMapping("/download/{id}")
    public ResponseEntity<byte[]> downloadFile(@PathVariable String id) {
        try {
            FileDownloadResponse downloadResponse = fileService.downloadFile(id);
            
            HttpHeaders headers = new HttpHeaders();
            headers.setContentType(MediaType.parseMediaType(downloadResponse.getContentType()));
            headers.setContentDisposition(
                ContentDisposition.attachment()
                    .filename(downloadResponse.getFileName())
                    .build()
            );

            return new ResponseEntity<>(downloadResponse.getContent(), headers, HttpStatus.SC_OK);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SC_NOT_FOUND).build();
        }
    }

    /**
     * Get all images
     */
    @GetMapping("/images")
    public ResponseEntity<Iterable<FileMetadata>> getAllImages() {
        Iterable<FileMetadata> images = fileService.getAllImageFiles();
        return ResponseEntity.ok(images);
    }

    /**
     * Delete file - removes from both SeaweedFS and database
     */
    @PostMapping("/delete/{id}")
    public ResponseEntity<String> deleteFile(@PathVariable String id) {
        try {
            fileService.deleteFile(id);
            return ResponseEntity.ok().build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.SC_INTERNAL_SERVER_ERROR)
                    .body("Failed to delete file: " + e.getMessage());
        }
    }
}