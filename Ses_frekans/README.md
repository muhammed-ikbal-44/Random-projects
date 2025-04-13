# Sound Frequency Experiment Interface

This project was developed in 2021 as part of a TÜBİTAK science competition. The goal was to investigate how different sound frequencies affect living beings—both humans and animals—and to use those effects for beneficial purposes such as stress reduction or animal control.

## Overview

The application allows users to upload, play, and manage sound files with specific frequency values. The platform was designed to experiment with emotional and behavioral responses triggered by various sound ranges.

## Features

- 🎵 **Sound Management**: Add sound files with frequency metadata. Store and display them using a local SQL Server database.
- ▶️ **Media Control**: Play, pause, and stop sounds using an embedded media player.
- 🎚 **Adjustments**: Modify frequency and volume with trackbars.
- 🧪 **Experiment Module**: A testing screen enables controlled playback for observation and analysis.
- 📁 **Categorization**: Sounds can be labeled as positive or negative to structure experiments.
- 🌙 **Theme Options**: Supports dark and light UI themes.
- 🔐 **Authentication**: Includes login and registration forms.
- ℹ️ **About Panel**: Contains background info about the project and its scientific objectives.



- **Language**: C# (.NET Framework)
- **UI**: Windows Forms (WinForms)
- **Database**: SQL Server (local instance)


## Project Structure

- `Form1.cs`: Main interface with data listing, playback, and theme controls.
- `FrmGiriş.cs`: Login screen.
- `FrmKayıt.cs`: User registration screen.
- `FrmSesOdası.cs`: Panel for tagging sounds as “positive” or “negative”.
- `FormDeney.cs`: Experimental test screen.
- `FrmHakkımızda.cs`: Informational section about the project's purpose.



