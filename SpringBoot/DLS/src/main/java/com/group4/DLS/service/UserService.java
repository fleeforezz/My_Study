package com.group4.DLS.service;

import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.dto.request.UserUpdateReq;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.exception.AppException;
import com.group4.DLS.exception.enums.ErrorCode;
import com.group4.DLS.repository.UserRepository;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepo;

    // Get all users
    public List<User> getAllUsers() {
        return userRepo.findAll();
    }

    // Get user by ID
    public User getUserById(String id) {
        return userRepo.findById(id)
            .orElseThrow(() -> new AppException(ErrorCode.USER_NOT_FOUND));
    }

    // Create user with email uniqueness check
    public User createUser(UserCreationReq request) {
        User user = new User();

        if (userRepo.existsByEmail(request.getEmail())) {
            throw new AppException(ErrorCode.USER_EXISTS);
        }

        user.setUsername(request.getUsername());
        user.setPassword(request.getPassword());
        user.setEmail(request.getEmail());
        user.setStatus(request.getStatus());

        return userRepo.save(user);
    }

    // Update user details
    public User updateUser(String id, UserUpdateReq request) {
        User user = userRepo.findById(id)
            .orElseThrow(() -> new AppException(ErrorCode.USER_NOT_FOUND));

        if (user != null) {
            user.setUsername(request.getUsername());
            user.setPassword(request.getPassword());
            user.setEmail(request.getEmail());
            user.setStatus(request.getStatus());

            return userRepo.save(user);
        }

        return null;
    }

    // Delete user by ID
    public void deleteUser(String id) {
        User user = userRepo.findById(id)
            .orElseThrow(() -> new AppException(ErrorCode.USER_NOT_FOUND));

        if (user != null) {
            userRepo.delete(user);
            return;
        }
    }
}
