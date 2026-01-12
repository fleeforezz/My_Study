package com.group4.DLS.repository;

import java.util.List;

public interface IRepository<T> {
    List<T> getAll();
    T getById(int id);
    T Update(T t);
    void delete(int id);
}
