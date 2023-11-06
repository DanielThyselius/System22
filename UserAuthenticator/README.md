# User Authentication System with Mocks
Exercise we got from ChatGPT and we'll ajust slightly as we go along.

## Exercise Description

Create a user authentication system and write unit tests using mocks for interactions with external services. The system should allow users to register, log in, and change their passwords. Mock external services such as email notifications and SMS notifications.

## Requirements

### 1. User Class

Create a `User` class to represent a user with properties like `UserId`, `Username`, `Password`, and `Email`.

### 2. Authentication Service

Implement an `AuthenticationService` class that provides methods for user registration, login, and password change. These methods should interact with external services for email notifications and SMS notifications.

### 3. Email Notification Service Interface

Define an interface, such as `IEmailNotificationService`, to represent an email notification service. This interface should include a method for sending email notifications.

### 4. SMS Notification Service Interface

Create an interface, such as `ISmsNotificationService`, to represent an SMS notification service. This interface should include a method for sending SMS notifications.

### 5. Mock Email Notification Service

Implement a mock service, `MockEmailNotificationService`, that implements the `IEmailNotificationService` interface and simulates sending email notifications.

### 6. Mock SMS Notification Service

Implement a mock service, `MockSmsNotificationService`, that implements the `ISmsNotificationService` interface and simulates sending SMS notifications.

### 7. Unit Tests

Write unit tests for the `AuthenticationService` class using mocks for the email notification and SMS notification services. Test scenarios such as successful registration, login, password change, and error handling.

## Exercise Structure

- Start by creating the `User` class and the `AuthenticationService` class.
- Define the `IEmailNotificationService` and `ISmsNotificationService` interfaces.

- Write unit tests for the `AuthenticationService` class, mocking the email and SMS notification services with Moq. 
Test various scenarios, including successful operations and error handling.
- Use a mocking framework like Moq to set up different scenarios and expectations for email and SMS notifications.

This exercise provides a practical example of unit testing with mocks in the context of a user authentication system. It allows you to practice testing interactions with external services without making real network requests or sending actual notifications.
