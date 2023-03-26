# Problem
Code needs access to an object but doesn’t need a global point of access to it.

# Refactoring Subject
Move the Singleton’s features to a class that stores and provides access to the object. Delete the Singleton.