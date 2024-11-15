#!/bin/sh

# Ejecuta las migraciones
dotnet ef database update

# Inicia la aplicación
dotnet EcommerceApp.dll
