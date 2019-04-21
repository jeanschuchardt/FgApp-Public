FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY TC-FGApp/*.csproj ./TC-FGApp/
RUN dotnet restore

# Copy everything else and build
COPY TC-FGApp/. ./TC-FGApp/
WORKDIR /app/TC-FGApp
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/TC-FGApp/out ./
#Entrypoint = name of project
ENTRYPOINT ["dotnet", "TC-FGApp.dll"] 