FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /source
COPY . .

FROM build
RUN dotnet restore "./ocian-net/ocian-net.csproj" --disable-parallel
RUN dotnet publish "./ocian-net/ocian-net.csproj" -c release -o /app --no-restore


WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

# ENTRYPOINT [ "dotnet" ]