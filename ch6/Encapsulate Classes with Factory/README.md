# Problem
Clients directly instantiate classes that reside in one package and implement a common interface.

# Refactoring Subject
Make the class constructors non-public and let clients create instances of them using a Factory.