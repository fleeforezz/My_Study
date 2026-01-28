package com.group4.DLS.domain.dto.response;

import lombok.Data;
import lombok.experimental.FieldDefaults;

@Data
@FieldDefaults(level = lombok.AccessLevel.PRIVATE)
public class AssignResponse {
    String id;
    String url;
    String publicUrl;
    private int count;
}
