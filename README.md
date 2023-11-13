
<p align="center">
  <strong>Software Design Eksamen - TEAM FLEXUS</strong>
</p>



<strong>List over implemented requirements according to exam handout, along with where they are implemented</strong>
- [X] [Where - File location and line in file?] - Feature added
- [ ] [] -  


Todo (w)
- [ ] - Create a seperate hashing method for password (use dependency injection, or string extension method)
- [ ] - Create a custom userNotFoundException : Exception class for trying to find user by e-mail if not successfull
- [ ] - Refactor code so password is not sent around, it should not be in user objects other than when authenticating or registering
- [ ] - Fix tests with DB teardown or use another context (this requires some advanced dependency injection, which should be implemented)
- [ ] - Can throw custom exception when something goes wrong
- [ ] - Move password checking logic from signup presenter to register method in user service
- [ ] - Change the login and register methods to take in strings rather than user objects
- [ ] - Some sort of check for when creating workouts that it is in fact associated with a user before inserting it
