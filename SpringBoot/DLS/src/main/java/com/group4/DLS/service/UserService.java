package com.group4.DLS.service;

import com.group4.DLS.domain.entity.User;
import com.group4.DLS.repository.UserRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserService {
    private UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public List<User> listAllUserService() {
        return userRepository.getAll();
    }
}
