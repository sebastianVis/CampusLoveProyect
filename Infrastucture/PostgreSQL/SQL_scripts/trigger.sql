CREATE OR REPLACE FUNCTION actualizar_estadisticas_match()
RETURNS TRIGGER AS $$
BEGIN
    -- Actualizar estadisticas para el primer usuario
    UPDATE estadisticas
    SET total_matches = total_matches + 1,
        ultima_actualizacion = NOW()
    WHERE id_usuario = NEW.id_usuario_uno;
    
    -- Actualizar estadisticas para el segundo usuario
    UPDATE estadisticas
    SET total_matches = total_matches + 1,
        ultima_actualizacion = NOW()
    WHERE id_usuario = NEW.id_usuario_dos;
    
    -- Retornar el NEW registro para completar la inserción
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Crear el trigger que se ejecuta después de una inserción en la tabla matches
CREATE TRIGGER trig_actualizar_matches
AFTER INSERT ON matches
FOR EACH ROW
EXECUTE FUNCTION actualizar_estadisticas_match();