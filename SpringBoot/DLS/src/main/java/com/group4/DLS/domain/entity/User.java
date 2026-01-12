package com.group4.DLS.domain.entity;

import java.time.LocalDate;

public class User {
    private String id;
    private String username;
    private String password;
    private String email;
    private enum status {
        active, inactive
    };
    private LocalDate created_at;
}
