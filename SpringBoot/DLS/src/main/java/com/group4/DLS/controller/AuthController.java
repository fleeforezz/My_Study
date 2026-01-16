package com.group4.DLS.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.group4.DLS.domain.dto.request.ApiResponse;
import com.group4.DLS.domain.dto.request.AuthReq;
import com.group4.DLS.domain.dto.response.AuthResponse;
import com.group4.DLS.service.AuthService;

import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;



@RestController
@RequiredArgsConstructor
@FieldDefaults(level = lombok.AccessLevel.PRIVATE , makeFinal = true)
@RequestMapping("/api/v1/auth")
public class AuthController {
    
    AuthService authService;

    @PostMapping("/login")
    public ApiResponse<AuthResponse> login(@RequestBody AuthReq request) {
        boolean isAuthenticated = authService.authenticate(request);

        return ApiResponse.<AuthResponse>builder()
            .data(AuthResponse.builder()
                    .authenticated(isAuthenticated)
                    .build())
            .build();
    }
}
