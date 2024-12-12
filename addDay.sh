#!/usr/bin/env bash

create_project() {
  local project_name=$1

  if [ -z "$project_name" ]; then
    echo "Please provie a project name."
    return 1
  fi
  
  mkdir -p "$project_name"
  cd "$project_name"
  
  dotnet new console
  
  mkdir -p src data
  touch src/SolutionPart1.cs
  touch data/input.txt data/small-input.txt
  
  cd ..
  dotnet sln add "$project_name"
  
  echo "Project '$project_name' created successfully!"
}

if [ $# -eq 0 ]; then
  read -p "Enter project name: " project_name
  create_project "$project_name"
else
  create_project "$1"
fi