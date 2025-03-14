# University Enrollment System

This project is a University Enrollment System developed using C#. It provides a command-line interface to manage students and professors in a university setting.

## Features

- **User Management**
  - Add and track student records with their ID, full name, and major
  - Add and track professor records with their ID, full name, and department
  - Display all people sorted by their ID

- **Data Persistence**
  - Save all records to a text file (UniversityData.txt)
  - Load previously saved records from file
  - Automatic data saving when exiting the application

- **User Interface**
  - Simple and intuitive console menu system
  - Input validation to ensure data integrity

## System Requirements

- .NET Framework 6.0 or higher
- 50MB of free disk space
- Windows, macOS, or Linux operating system

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/Aoof/university-enrollment-system.git
    ```
2. Navigate to the project directory:
    ```sh
    cd university-enrollment-system
    ```
3. Build the project using your preferred C# development environment.

## Usage

1. Run the application from your C# development environment.
2. Navigate through the menu system by entering the corresponding number:
   - Option 1: Add a new student record
   - Option 2: Add a new professor record
   - Option 3: View all people sorted by ID
   - Option 4: Manually save data to file
   - Option 5: Load data from file
   - Option 6: Exit the application

## Project Structure

- **Driver.cs**: Contains the main program logic and menu system
- **Person.cs**: Base class for people in the university system
- **Student.cs**: Extends Person with student-specific attributes
- **Professor.cs**: Extends Person with professor-specific attributes

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any inquiries or support, please contact [Aoof](https://github.com/aoof).
