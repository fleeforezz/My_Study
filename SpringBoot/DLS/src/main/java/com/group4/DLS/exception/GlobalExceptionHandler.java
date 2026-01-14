package com.group4.DLS.exception;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

import com.group4.DLS.domain.dto.request.ApiResponse;
import com.group4.DLS.exception.enums.ErrorCode;

@ControllerAdvice
public class GlobalExceptionHandler {
    
    // Handle generic exceptions
    // Fallback for uncategorized errors
    @ExceptionHandler(value = Exception.class)
    public ResponseEntity<ApiResponse<String>> handleRuntimeException(Exception ex) {
        ApiResponse<String> response = new ApiResponse<>();
        ErrorCode errorCode = ErrorCode.UNCATEGORIZED;
        
        response.setCode(errorCode.getCode());
        response.setMessage(errorCode.getMessage());
        response.setData(null);

        return ResponseEntity
            .badRequest()
            .body(response);
    }

    // More flexible response based on ErrorCode
    @ExceptionHandler(value = AppException.class)
    public ResponseEntity<ApiResponse<String>> handleAppException(AppException ex) {
        ApiResponse<String> response = new ApiResponse<>();
        ErrorCode errorCode = ex.getCode();
        
        response.setCode(errorCode.getCode());
        response.setMessage(errorCode.getMessage());
        response.setData(null);

        return ResponseEntity
            .badRequest()
            .body(response);
    }

    // Handle validation errors
    @ExceptionHandler(value = MethodArgumentNotValidException.class)
    public ResponseEntity<String> handleValidation(MethodArgumentNotValidException ex) {
        return ResponseEntity
            .badRequest()
            .body(ex.getBindingResult().getAllErrors().get(0).getDefaultMessage());
    }
}
