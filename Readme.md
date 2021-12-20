-Benefits of Clean Architecture

    Independent of Database and Frameworks.
    Independent of the presentation layer. Anytime we can change the UI without changing the rest of the system and business logic.
    Highly testable, especially the core domain model and its business rules are extremely testable.



-Here in the application layer, we will segregate queries from the command so we will implement CQRS here.