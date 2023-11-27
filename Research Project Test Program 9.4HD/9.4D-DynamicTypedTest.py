import time

# Dynamic Type System Test Program
def example1():
    #Example 1: Adding strings
    message2 = " to the cowboys"
    message = "Friendly hello hi"
    output = message + message2
    print(output)

def example2():
    #Example 2: Adding ints
    x = 10

    #Case 1: adding string to int and output as int
    y = "Guava";

    #Case 2: adding int to int and output as int
    #y = 20

    sum = x + y
    print(sum)


# Measure execution time for dynamic type system
start_time = time.time()
example1()
example2()
run_time = time.time() - start_time

# Print execution times
print("\nExecution Time Comparison:")
print("Dynamic Type System:", run_time, "seconds")