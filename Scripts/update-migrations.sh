#!/bin/bash
dotnet ef database update --context BlogContext;
dotnet ef database update --context UserContext;