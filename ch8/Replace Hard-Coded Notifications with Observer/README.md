# Problem
Subclasses are hard-coded to notify a single instance of another class.

# Refactoring Subject
Remove the subclasses by making their superclass capable of notifying one or more instances of any class that implements an Observer interface.