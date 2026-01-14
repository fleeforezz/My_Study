package com.group4.DLS.exception.enums;

import lombok.Getter;
import lombok.RequiredArgsConstructor;

@Getter
@RequiredArgsConstructor
public enum ErrorCode {
    UNCATEGORIZED(999, "Uncategorized error"),
    
    USER_NOT_FOUND(404, "User not found"),
    USER_EXISTS(409, "User already exists"),

    INVALID_USERNAME(400, "Invalid username"),
    INVALID_PASSWORD(400, "Invalid password"),
    INVALID_EMAIL(400, "Invalid email"),
    
    INTERNAL_SERVER_ERROR(500, "Internal server error");

    private final int code;
    private final String message;
}