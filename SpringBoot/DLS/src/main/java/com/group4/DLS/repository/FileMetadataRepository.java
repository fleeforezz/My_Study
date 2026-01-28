package com.group4.DLS.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import com.group4.DLS.domain.entity.FileMetadata;

public interface FileMetadataRepository extends JpaRepository<FileMetadata, String> {
    Optional<FileMetadata> findByFileId(String fileId);
    List<FileMetadata> findByFileName(String fileName);
    Iterable<FileMetadata> findByContentTypeStartingWith(String contentType);
}
