﻿using LinkedInWebApi.Core.Dto;

namespace LinkedInWebApi.Reposirotry.Commands.Insert
{
    public interface IMessageInsertCommands
    {
        Task<bool> InsertMessage(NewMessageDto newMessage);
    }
}
