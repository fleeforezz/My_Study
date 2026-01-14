package com.group4.DLS.controller;

import com.group4.DLS.domain.dto.request.ApiResponse;
import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.dto.request.UserUpdateReq;
import com.group4.DLS.domain.dto.response.UserResponse;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.service.UserService;

import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;


@RestController
@RequiredArgsConstructor
@FieldDefaults(level = lombok.AccessLevel.PRIVATE , makeFinal = true)
@RequestMapping("/api/v1/users")
public class UserController {

    UserService userService;

    /*
    * ================
    * CRUD Operations
    * ===============
    */
    @GetMapping
    public ApiResponse<List<User>> getAllUsers() {
        ApiResponse<List<User>> response = new ApiResponse<>();

        response.setCode(200);
        response.setMessage("Users fetched successfully");
        response.setData(userService.getAllUsers());

        return response;
    }

    @GetMapping("/{id}")
    public ApiResponse<UserResponse> getUserById(@PathVariable String id) {
        ApiResponse<UserResponse> response = new ApiResponse<>();

        response.setCode(200);
        response.setData(userService.getUserById(id));
        response.setMessage("User fetched successfully");

        return response;
    }
    

    @PostMapping
    public ApiResponse<UserResponse> createUser(@RequestBody @Valid UserCreationReq request) {
        ApiResponse<UserResponse> response = new ApiResponse<>();

        response.setCode(200);
        response.setMessage("User created successfully");
        response.setData(userService.createUser(request));

        return response;
    }

    @PutMapping("/{id}")
    public ApiResponse<User> updateUser(@PathVariable String id, @RequestBody @Valid UserUpdateReq request) {
        ApiResponse<User> response = new ApiResponse<>();

        response.setCode(200);
        response.setMessage("User updated successfully");
        response.setData(userService.updateUser(id, request));

        return response;
    }

    @DeleteMapping("/{id}")
    public ApiResponse<User> deleteUser(@PathVariable String id) {
        ApiResponse<User> response = new ApiResponse<>();
        userService.deleteUser(id);

        response.setCode(200);
        response.setMessage("User deleted successfully");
        response.setData(null);

        return response;
    }
}
