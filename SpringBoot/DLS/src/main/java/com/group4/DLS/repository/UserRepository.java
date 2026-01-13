package com.group4.DLS.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.group4.DLS.domain.entity.User;

@Repository
public interface UserRepository extends JpaRepository<User, String> {
}
