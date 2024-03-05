{
  "Jwt": {
    "Issuer": "your-issuer",
    "Audience": "your-audience",
    "Secret": "your-secret-key"
  },
  "Serilog": {
    "MinimumLevel": "Debug",
    "Override": {
      "Microsoft": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console"
      }
    ]
  }
}