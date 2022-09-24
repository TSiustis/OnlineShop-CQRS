﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Order.Commands.DeleteOrder;
public class DeleteOrderCommand : IRequest
{
    public DeleteOrderCommand(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
