package com.group4.DLS.repository;

import com.group4.DLS.domain.entity.User;

import java.util.List;

public class UserRepository implements IRepository<User> {

    @Override
    public List<User> getAll() {
        return List.of();
    }

    @Override
    public User getById(int id) {
        return null;
    }

    @Override
    public User Update(User user) {
        return null;
    }

    @Override
    public void delete(int id) {

    }
}
