#!/bin/bash

# Define o diretório raiz do seu projeto
rootDir="/Users/claudiobispo/Documents/DOTNET/project-backend-challenge-odontoprev/ProjetoOdontoPrev"

# Define a estrutura de pastas
folders=(
    "$rootDir/src/Domain/Entities"
    "$rootDir/src/Domain/ValueObjects"
    "$rootDir/src/Domain/Interfaces"
    "$rootDir/src/Domain/Services"
    "$rootDir/src/Domain/Exceptions"
    "$rootDir/src/Application/Interfaces"
    "$rootDir/src/Application/Services"
    "$rootDir/src/Application/Commands"
    "$rootDir/src/Application/Queries"
    "$rootDir/src/Application/DTOs"
    "$rootDir/src/Infrastructure/Data/Context"
    "$rootDir/src/Infrastructure/Data/Migrations"
    "$rootDir/src/Infrastructure/Data/Repositories"
    "$rootDir/src/Infrastructure/Services"
    "$rootDir/src/Infrastructure/Email"
    "$rootDir/src/Presentation/Controllers"
    "$rootDir/src/Presentation/ViewModels"
    "$rootDir/src/Presentation/Middlewares"
)

# Cria as pastas
for folder in "${folders[@]}"; do
    mkdir -p "$folder"
done

echo "Estrutura de pastas criada com sucesso!"
