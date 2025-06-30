FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# نسخ ملف السوليوشن
COPY Quiz_App.sln .

# نسخ ملفات المشاريع حسب المسارات
COPY src/Account/Account.API/Account.API.csproj Account.API/
COPY src/Account/Account.Application/Account.Application.csproj Account.Application/
COPY src/Account/Account.Domain/Account.Domain.csproj Account.Domain/
COPY src/Account/Acccount.Infrastructure/Acccount.Infrastructure.csproj Account.Infrastructure/

COPY src/Exam/Exam.API/Exam.API.csproj Exam.API/
COPY src/Exam/Exam.Application/Exam.Application.csproj Exam.Application/
COPY src/Exam/Exam.Domain/Exam.Domain.csproj Exam.Domain/
COPY src/Exam/Exam.Infrastructure/Exam.Infrastructure.csproj Exam.Infrastructure/

COPY quiz_system/quiz_system.csproj quiz_system/  # ← لو عندك مشروع فعلي هنا بيحتوي على Program.cs

# restore
RUN dotnet restore Quiz_App.sln

# نسخ باقي الملفات
COPY . .

# publish
RUN dotnet publish quiz_system/quiz_system.csproj -c Release -o /app/out

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "quiz_system.dll"]  # ← غيّر الاسم لو الملف الناتج مختلف