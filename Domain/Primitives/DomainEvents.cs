﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.Primitives
{
    public record  DomainEvents (Guid Id):INotification;
}
