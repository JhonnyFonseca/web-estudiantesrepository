drop procedure if exists mydb.EstudianteCurso;

DELIMITER $$ 
create procedure mydb.EstudianteCurso (
in oper varchar(2),
in idEstudiante int
)
begin
if (oper = 'ie') then
	select * from mydb.estudiante;
end if;

if (oper = 'fe') then
	select * from mydb.estudiante
	where estudiante.Idestudiante = idEstudiante ;
end if;

if (oper = 'ic') then
	set @curso = 0;

	set @curso = (select curso.idCurso
    from mydb.curso 
	left outer join mydb.cursosestudiante 
	on curso.Idcurso = cursosestudiante.idcurso
	where 
	cursosestudiante.idEstudiante = idestudiante);
    
    select * from mydb.curso where idCurso <> @curso;
end if;

if (oper = 'fc') then
	set @curso = 0;

	set @curso = (select curso.idCurso
    from mydb.curso 
	left outer join mydb.cursosestudiante 
	on curso.Idcurso = cursosestudiante.idcurso
	where 
	cursosestudiante.idEstudiante = idestudiante);
    
    select * from mydb.curso where idCurso = @curso;
end if;

if (oper = 'ac') then
    select * from mydb.curso;
end if;

end $$
DELIMITER ;

-- call mydb.EstudianteCurso('ac', 1);
