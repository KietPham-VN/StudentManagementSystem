﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Async/await", "CRR0029:ConfigureAwait(true) is called implicitly", Justification = "<Pending>")]
[assembly: SuppressMessage("Async/await", "CRR0035:No CancellationToken parameter in the asynchronous method", Justification = "<Pending>", Scope = "member", Target = "~M:Web.Controllers.UserController.LoginJwtAsync(Application.DTOs.UserDTO.UserLoginModel)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]