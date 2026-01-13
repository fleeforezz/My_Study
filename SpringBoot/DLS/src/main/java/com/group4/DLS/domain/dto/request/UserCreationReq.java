package com.group4.DLS.domain.dto.request;

import com.group4.DLS.domain.enums.UserStatus;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class UserCreationReq {

    private String username;
    private String password;
    private String email;
    private UserStatus status;
    
}