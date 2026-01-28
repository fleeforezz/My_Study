package com.group4.DLS.domain.dto.response;

import java.util.List;

import lombok.Data;
import lombok.experimental.FieldDefaults;

@Data
@FieldDefaults(level = lombok.AccessLevel.PRIVATE)
public class LookupResponse {
    String volumeId;
    List<Location> locations;

    @Data
    @FieldDefaults(level = lombok.AccessLevel.PRIVATE)
    public static class Location {
        String url;
        String publicUrl;
    }
}
