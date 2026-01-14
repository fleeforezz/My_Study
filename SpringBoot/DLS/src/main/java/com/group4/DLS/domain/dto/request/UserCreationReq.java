package com.group4.DLS.domain.dto.request;

import com.group4.DLS.domain.enums.UserStatus;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class UserCreationReq {

    @Size(min = 3, max = 50, message = "INVALID_USERNAME")
    private String username;

    @Size(min = 8, message = "INVALID_PASSWORD")
    private String password;

    @Email(message = "INVALID_EMAIL")
    private String email;
    
    private UserStatus status;
    
}