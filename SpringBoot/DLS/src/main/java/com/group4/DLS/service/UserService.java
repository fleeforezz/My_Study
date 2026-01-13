package com.group4.DLS.service;

import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.repository.UserRepository;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepository;

    public List<User> getAllUsers() {
        return userRepository.findAll();
    }

    public User createUser(UserCreationReq request) {
        User user = new User();

        user.setUsername(request.getUsername());
        user.setPassword(request.getPassword());
        user.setEmail(request.getEmail());
        user.setStatus(request.getStatus());

        return userRepository.save(user);
    }
}
