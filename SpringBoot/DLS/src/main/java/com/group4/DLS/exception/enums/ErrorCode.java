package com.group4.DLS.exception.enums;

import lombok.Getter;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;

@Getter
@FieldDefaults(level = lombok.AccessLevel.PRIVATE)
@RequiredArgsConstructor
public enum ErrorCode {
    UNCATEGORIZED(999, "Uncategorized error"),
    
    USER_NOT_FOUND(404, "User not found"),
    USER_EXISTS(409, "User already exists"),
    UNAUTHENTICATED(410, "UnAuthenticated"),

    INVALID_USERNAME(400, "Invalid username"),
    INVALID_PASSWORD(400, "Invalid password"),
    INVALID_EMAIL(400, "Invalid email"),

    INTERNAL_SERVER_ERROR(500, "Internal server error");

    final int code;
    final String message;
}