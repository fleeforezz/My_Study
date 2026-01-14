package com.group4.DLS.mapper;

import org.mapstruct.Mapper;

import com.group4.DLS.domain.dto.request.UserCreationReq;
import com.group4.DLS.domain.entity.User;

@Mapper(componentModel = "spring")
public interface UserMapper {
    User toUser(UserCreationReq request);
}
