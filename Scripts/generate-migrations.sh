#!/bin/bash
dotnet ef migrations add InitialCreate --context BlogContext --output-dir Migrations/Blog;
dotnet ef migrations add InitialCreate --context UserContext --output-dir Migrations/User;