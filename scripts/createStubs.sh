for d in */ ; do
	d2=${d:0:${#d}-1}
	echo d2
	touch $d2/$d2.cs
done
