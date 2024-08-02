was = []
while (True):
    wa = input()
    if (wa == ''):
        break
        
    was.append(wa)

print("------------------")
for i in range(0, len(was), 2):
    print('{"name": "' + was[i] + '", "description": "' + was[i + 1] + '"},')
