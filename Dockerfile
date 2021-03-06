FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app



# Copy everything else and build
COPY . ./
RUN apt-get update && apt-get install -y nuget
RUN dotnet restore
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
#RUN docker run -p 9090:9090 -v /tmp/prometheus.yml:/etc/prometheus/prometheus.yml prom/prometheus
CMD ["dotnet", "aspnetapp.dll"]
RUN echo "global:\
  scrape_interval:     15s # Set the scrape interval to every 15 seconds. Default is every 1 minute.\
  evaluation_interval: 15s # Evaluate rules every 15 seconds. The default is every 1 minute.\
  \
scrape_configs:\
  - job_name: 'netcore-prometheus'\
    # metrics_path defaults to '/metrics'\
    static_configs:\
    - targets: [':8080']" >> /tmp/prometheus.yml