package com.group4.DLS.controller;

import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;



@RestController
@RequestMapping("/users")
public class UserController {

    @Autowired
    private UserService userService;

    @PostMapping
    public User createUser(@RequestBody UserCreationReq request) {
        return userService.createUser(request);
    }

    @GetMapping("/ping")
    public String ping() {
        return "pong";
    }
}
