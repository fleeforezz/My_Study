package com.group4.DLS.controller;

import com.group4.DLS.domain.dto.request.ApiResponse;
import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.dto.request.UserUpdateReq;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.service.UserService;

import jakarta.validation.Valid;

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
@RequestMapping("/api/v1/users")
public class UserController {

    @Autowired
    private UserService userService;

    /*
    * ================
    * CRUD Operations
    * ===============
    */
    @GetMapping
    public List<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @GetMapping("/{id}")
    public User getUserById(@PathVariable String id) {
        return userService.getUserById(id);
    }
    

    @PostMapping
    public ApiResponse<User> createUser(@RequestBody @Valid UserCreationReq request) {
        ApiResponse<User> response = new ApiResponse<>();

        response.setCode(200);
        response.setMessage("User created successfully");
        response.setData(userService.createUser(request));

        return response;
    }

    @PutMapping("/{id}")
    public User updateUser(@PathVariable String id, @RequestBody @Valid UserUpdateReq request) {
        return userService.updateUser(id, request);
    }

    @DeleteMapping("/{id}")
    public void deleteUser(@PathVariable String id) {
        userService.deleteUser(id);
    }
}
