# Problem
You need a superclass and/or interface to have the same interface as a subclass.

# Refactoring Subject
Find all public methods on the subclass that are missing on the superclass/interface. Add copies of these missing methods to the superclass, altering each one to perform null behavior.