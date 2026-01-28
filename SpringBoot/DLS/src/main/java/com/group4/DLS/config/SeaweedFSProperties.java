package com.group4.DLS.config;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

import lombok.Data;
import lombok.Getter;
import lombok.Setter;

@Data
@Component
@ConfigurationProperties(prefix = "seaweedfs")
public class SeaweedFSProperties {
    private Master master = new Master();
    private Volume volume = new Volume();
    private PublicUrl publicUrl = new PublicUrl();

    @Getter
    @Setter
    public static class Master {
        private String url;
    }

    @Getter
    @Setter
    public static class Volume {
        private String url;
    }

    @Getter
    @Setter
    public static class PublicUrl {
        private String url;
    }
}
