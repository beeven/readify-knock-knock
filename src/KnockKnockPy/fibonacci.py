from decimal import Decimal,getcontext
getcontext().prec = 218

def fib(n):
	SQRT5 = Decimal(5).sqrt()
	PHI = (SQRT5+1)/2
	return int(PHI**n/SQRT5 + Decimal(0.5))

def fibonacci(n):
        a,b=0,1
        for i in range(abs(n)):
            a,b = b, a+b
        if n<0 and n%2 ==0:
            return -a
        else:
            return a

def mult(A,B):
	return (A[0]*B[0]+A[1]*B[2],A[0]*B[1]+A[1]*B[3],A[2]*B[0]+A[3]*B[2],A[2]*B[1]+A[3]*B[3])
def power(A,n):
	x = (1,0,1,0)
	while n > 0:
		if n % 2 == 1:
			x = mult(x,A)
			if n == 1: break
		A = mult(A,A)
		n //= 2
	return x
def fibM(n):
	return power((1,1,1,0),n)[1]

