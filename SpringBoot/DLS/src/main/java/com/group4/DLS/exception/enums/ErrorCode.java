package com.group4.DLS.exception.enums;

import lombok.Getter;
import lombok.RequiredArgsConstructor;

@Getter
@RequiredArgsConstructor
public enum ErrorCode {
    USER_NOT_FOUND(404, "User not found"),
    USER_EXISTS(409, "User already exists"),
    INVALID_INPUT(400, "Invalid input"),
    INTERNAL_SERVER_ERROR(500, "Internal server error");

    private final int code;
    private final String message;
}