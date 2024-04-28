PowerUp = Class {}

function PowerUp:init(image)
    self.image = image
    self.width = 16
    self.height = 16
    self.x = math.random(0, 286)
    self.y = 0
    self.dy = 55
    self.dx = 0
    self.used = false
end

function PowerUp:collides(target)
    if self.x > target.x + target.width or target.x > self.x + self.width then
        return false
    end

    if self.y > target.y + target.height or target.y > self.y + self.height then
        return false
    end

    return true
end

function PowerUp:update(dt)
    self.x = self.x + math.random(-80, 80) * dt
    self.y = self.y + self.dy * dt

    if self.x > 416 then
        self.x = 416
    end

    if self.x < 16 then
        self.x = 16
    end

    if self.y <= 0 then
    end
end

function PowerUp:render()
    --if self.image == 'pumb' then
    love.graphics.draw(gTextures['main'], gFrames[self.image],
        self.x, self.y)
    --end
end

function PowerUp:set(s)
    self.image = s
end
