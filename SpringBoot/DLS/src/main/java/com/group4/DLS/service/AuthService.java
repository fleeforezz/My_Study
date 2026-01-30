package com.group4.DLS.service;

import java.util.Date;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import com.group4.DLS.domain.dto.request.AuthReq;
import com.group4.DLS.domain.dto.response.AuthResponse;
import com.group4.DLS.exception.AppException;
import com.group4.DLS.exception.enums.ErrorCode;
import com.group4.DLS.repository.UserRepository;

import io.jsonwebtoken.Jwts;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;

@Service
@RequiredArgsConstructor
@FieldDefaults(level = lombok.AccessLevel.PRIVATE, makeFinal = true)
public class AuthService {

    UserRepository userRepo;
    
    public AuthResponse authenticate(AuthReq request) {
        var user = userRepo.findByEmail(request.getEmail())
            .orElseThrow(() -> new AppException(ErrorCode.USER_NOT_FOUND));

        PasswordEncoder encoder = new BCryptPasswordEncoder(10);

        boolean authenticated = encoder.matches(request.getPassword(), user.getPassword());

        if (!authenticated) {
            throw new AppException(ErrorCode.UNAUTHENTICATED);
        }

        return
    }
}
