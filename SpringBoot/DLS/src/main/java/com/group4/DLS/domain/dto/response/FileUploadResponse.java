package com.group4.DLS.domain.dto.response;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class FileUploadResponse {
    String fileId;
    String fileUrl;
    String fileName;
    String contentType;
    Long fileSize;
}
