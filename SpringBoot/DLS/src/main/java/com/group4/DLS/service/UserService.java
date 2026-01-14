package com.group4.DLS.service;

import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.dto.request.UserUpdateReq;
import com.group4.DLS.domain.entity.User;
import com.group4.DLS.repository.UserRepository;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserService {
    @Autowired
    private UserRepository userRepo;

    public List<User> getAllUsers() {
        return userRepo.findAll();
    }

    public User getUserById(String id) {
        return userRepo.findById(id)
            .orElseThrow(() -> new RuntimeException("User not found"));
    }

    public User createUser(UserCreationReq request) {
        User user = new User();

        if (userRepo.existsByEmail(request.getEmail())) {
            throw new RuntimeException("Email already in use");
        }

        user.setUsername(request.getUsername());
        user.setPassword(request.getPassword());
        user.setEmail(request.getEmail());
        user.setStatus(request.getStatus());

        return userRepo.save(user);
    }

    public User updateUser(String id, UserUpdateReq request) {
        User user = userRepo.findById(id)
            .orElseThrow(() -> new RuntimeException("User not found"));

        if (user != null) {
            user.setUsername(request.getUsername());
            user.setPassword(request.getPassword());
            user.setEmail(request.getEmail());
            user.setStatus(request.getStatus());

            return userRepo.save(user);
        }

        return null;
    }

    public void deleteUser(String id) {
        User user = userRepo.findById(id)
            .orElseThrow(() -> new RuntimeException("User not found"));

        if (user != null) {
            userRepo.delete(user);
            return;
        }
    }
}
